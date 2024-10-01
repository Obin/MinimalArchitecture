using System;

namespace MinimalArchitecture.Api.Responses
{
    public class CreateResponse
    {
        public Guid Id { get; set; }

        public CreateResponse(Guid id)
        {
            Id = id;
        }
    }
}