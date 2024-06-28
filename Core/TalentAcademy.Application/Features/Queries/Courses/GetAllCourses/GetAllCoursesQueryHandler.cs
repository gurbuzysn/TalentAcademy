using AutoMapper;
using MediatR;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Queries.Courses.GetAllCourses
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQueryRequest, List<GetAllCoursesQueryResponse>>
    {
        private readonly IReadRepository<Course> _readRepository;
        private readonly IMapper _mapper;
        public GetAllCoursesQueryHandler(IReadRepository<Course> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCoursesQueryResponse>> Handle(GetAllCoursesQueryRequest request, CancellationToken cancellationToken)
        {
            var allCourse = await _readRepository.GetAllAsync();

            var response = _mapper.Map<List<GetAllCoursesQueryResponse>>(allCourse);

            foreach (var course in response)
            {
                course.ImageUri = $"https://localhost:7043/images/{course.ImageUri}";
            }

            return response;
        }
    }
}







