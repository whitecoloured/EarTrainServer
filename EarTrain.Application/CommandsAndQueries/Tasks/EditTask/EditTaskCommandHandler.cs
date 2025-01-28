using EarTrain.Infrastructure.Context;
using EarTrain.Core.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using EarTrain.Core.Exceptions;

namespace EarTrain.Application.CommandsAndQueries.Tasks.EditTask
{
    public class EditTaskCommandHandler(ETContext context, IValidator<TaskCommand> validator) : IRequestHandler<EditTaskCommand, Unit>
    {
        private readonly ETContext _context = context;
        private readonly IValidator<TaskCommand> _validator = validator;
        public async Task<Unit> Handle(EditTaskCommand request, CancellationToken cancellationToken)
        {
            var modelState = _validator.Validate(request.Command);

            if (!modelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n', modelState.Errors));
            }

            if (await _context.ChangedSounds.AnyAsync(p=> p.SoundSrc==request.Command.ChangedSoundSrc,cancellationToken))
            {
                throw new BadRequestException("Установите уникальный измененный аудиофайл!");
            }

            ChangedSound changedSound = ChangedSound.Create(request.Command.ChangedSoundSrc, request.Command.SoundCategory);

            await _context.ChangedSounds.AddAsync(changedSound,cancellationToken);

            Sound sound = default;

            if (await _context.Sounds.AnyAsync(p=> p.SoundSrc==request.Command.OGSoundSrc,cancellationToken))
            {
                sound = await _context.Sounds.FirstOrDefaultAsync(p => p.SoundSrc == request.Command.OGSoundSrc,cancellationToken);
                sound.Category = request.Command.SoundCategory;
            }
            else
            {
                sound = Sound.Create(request.Command.OGSoundSrc, request.Command.SoundCategory);
                await _context.Sounds.AddAsync(sound,cancellationToken);
            }

            await _context.Tasks
                    .Where(p => p.Id == request.TaskID)
                    .ExecuteUpdateAsync(opt=>
                        opt
                        .SetProperty(p => p.OGSound, sound)
                        .SetProperty(p => p.ChangedSound, changedSound)
                        .SetProperty(p => p.Answer, request.Command.Answer)
                        .SetProperty(p=>  p.Category, request.Command.TaskCategory),
                        cancellationToken
                    );

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;


        }
    }
}
