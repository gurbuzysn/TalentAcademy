using MediatR;

namespace TalentAcademy.Application.Features.Queries.Users.GetUserById
{
    public class GetUserByIdQueryRequest : IRequest<GetUserByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetUserByIdQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
