using EarTrain.Core.Models;
using EarTrain.Infrastructure.Context;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EarTrain.Core.Exceptions;

namespace EarTrain.Application.CommandsAndQueries.Tasks.AddTask
{
    public class AddTaskCommandHandler(ETContext context, IValidator<TaskCommand> validator) : IRequestHandler<AddTaskCommand,Unit>
    {
        private readonly ETContext _context = context;
        private readonly IValidator<TaskCommand> _validator = validator;


        //Must be reviewed later!!!!
        public async Task<Unit> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var modelState=_validator.Validate(request.Command);

            if (!modelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n',modelState.Errors));
            }

            if (await _context.ChangedSounds.AnyAsync(p => p.SoundSrc == request.Command.ChangedSoundSrc, cancellationToken))
            {
                throw new BadRequestException("Установите уникальный измененный аудиофайл!");
            }

            Sound sound = default;
            ChangedSound changedSound = ChangedSound.Create(request.Command.ChangedSoundSrc, request.Command.SoundCategory);

            if (await _context.Sounds.AnyAsync(p => p.SoundSrc == request.Command.OGSoundSrc,cancellationToken))
            {
                sound = await _context.Sounds.FirstOrDefaultAsync(p => p.SoundSrc == request.Command.OGSoundSrc, cancellationToken);
            }
            else
            {
                sound = Sound.Create(request.Command.OGSoundSrc, request.Command.SoundCategory);
                await _context.Sounds.AddAsync(sound, cancellationToken);
            }

            await _context.ChangedSounds.AddAsync(changedSound, cancellationToken);


            var task = TrainTask.Create(request.Command.TaskCategory, sound, changedSound, request.Command.Answer);

            await _context.Tasks.AddAsync(task, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
