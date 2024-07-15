using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Commands.Courses.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommandRequest>
    {
        private readonly IWriteRepository<Course> _writeRepository;
        private readonly IReadRepository<Course> _readRepository;

        public DeleteCourseCommandHandler(IWriteRepository<Course> writeRepository, IReadRepository<Course> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }
        public async Task Handle(DeleteCourseCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedCourse = await _readRepository.GetByIdAsync(request.Id);
            if (deletedCourse == null)
                return;

            await _writeRepository.RemoveAsync(deletedCourse);
        }
    }
}
