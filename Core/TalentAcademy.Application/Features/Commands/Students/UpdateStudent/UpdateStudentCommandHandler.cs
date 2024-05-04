using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Commands.Students.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommandRequest>
    {
        private readonly IWriteRepository<Student> _writeRepository;
        private readonly IReadRepository<Student> _readRepository;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IWriteRepository<Student> writeRepository, IReadRepository<Student> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateStudentCommandRequest request, CancellationToken cancellationToken)
        {
            var student = await _readRepository.GetByIdAsync(request.Id);

            if (student != null)
            {
                student.FirstName = request.FirstName;
                student.LastName = request.LastName;
                student.Gender = request.Gender;
                student.BirthOfDate = request.BirthOfDate;
                student.Image = request.Image;

                await _writeRepository.UpdateAsync(student);
            }
        }
    }
}
