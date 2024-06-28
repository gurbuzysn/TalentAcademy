using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Queries.Courses.GetByCourseName
{
    public class GetByCourseNameQueryHandler : IRequestHandler<GetByCourseNameQueryRequest, GetByCourseNameQueryResponse>
    {
        private readonly IReadRepository<Course> _readRepository;
        private readonly IMapper _mapper;

        public GetByCourseNameQueryHandler(IReadRepository<Course> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<GetByCourseNameQueryResponse> Handle(GetByCourseNameQueryRequest request, CancellationToken cancellationToken)
        {
            var course = await _readRepository.GetByFilterAsync(x => x.Name == request.CourseName);

            course.ImageUri = $"https://localhost:7043/images/{course.ImageUri}";

            var courseResponse = _mapper.Map<GetByCourseNameQueryResponse>(course);

            return courseResponse;
        }
    }


}
