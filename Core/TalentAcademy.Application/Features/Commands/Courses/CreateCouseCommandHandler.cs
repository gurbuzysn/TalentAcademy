using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Commands.Courses
{
    public class CreateCouseCommandHandler : IRequestHandler<CreateCourseCommandRequest, CreateCourseCommandResponse>
    {
        private readonly IWriteRepository<Course> _writeRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public CreateCouseCommandHandler(IWriteRepository<Course> writeRepository, IMapper mapper, IWebHostEnvironment environment)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
            _environment = environment;
        }
        public async Task<CreateCourseCommandResponse> Handle(CreateCourseCommandRequest request, CancellationToken cancellationToken)
        {
            var newCourse = _mapper.Map<Course>(request);

            if(request.Image != null)
            {
                var imageFileName = $"{Guid.NewGuid()}{Path.GetExtension(request.Image.FileName)}";
                var imagePath = Path.Combine(_environment.WebRootPath, "images", imageFileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await request.Image.CopyToAsync(stream);
                }
                newCourse.ImageUri = $"{imageFileName}";
            }

            newCourse.CreatedDate = DateTime.UtcNow;


            try
            {
               await _writeRepository.CreateAsync(newCourse);
                return new CreateCourseCommandResponse();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
                
            }

        }
    }
}
