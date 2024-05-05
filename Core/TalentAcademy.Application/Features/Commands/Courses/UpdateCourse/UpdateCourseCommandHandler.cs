using AutoMapper;
using MediatR;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Commands.Courses.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommandRequest>
    {
        private readonly IReadRepository<Course> _readRepository;
        private readonly IWriteRepository<Course> _writeRepository;
        private readonly IMapper _mapper;

        public UpdateCourseCommandHandler(IReadRepository<Course> readRepository, IWriteRepository<Course> writeRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateCourseCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedCourse = await _readRepository.GetByIdAsync(request.Id);

            if (updatedCourse != null)
            {
                updatedCourse.Name = request.Name;
                updatedCourse.Description = request.Description;
                updatedCourse.UpdatedDate = DateTime.UtcNow;
                updatedCourse.Topics = request.Topics;
                updatedCourse.StudentCourses = request.StudentCourses;

                await _writeRepository.UpdateAsync(updatedCourse);
            }
        }
    }
}
