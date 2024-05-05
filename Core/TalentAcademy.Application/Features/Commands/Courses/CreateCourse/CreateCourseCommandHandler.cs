using AutoMapper;
using MediatR;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Commands.Courses.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommandRequest, CreateCourseCommandResponse>
    {
        private readonly IWriteRepository<Course> _writeRepository;
        private readonly IMapper _mapper;

        public CreateCourseCommandHandler(IWriteRepository<Course> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }
        public async Task<CreateCourseCommandResponse> Handle(CreateCourseCommandRequest request, CancellationToken cancellationToken)
        {
            var createdCourse = _mapper.Map<Course>(request);
            createdCourse.CreatedDate = DateTime.UtcNow;
            await _writeRepository.CreateAsync(createdCourse);
            return _mapper.Map<CreateCourseCommandResponse>(createdCourse);
        }
    }
}
