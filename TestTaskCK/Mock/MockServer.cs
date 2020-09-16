using System;
using System.Collections.Generic;
using System.Text;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace TestTaskCK.Mock
{
    class MockServer
    {
        public void CreateMock()
        {
            var server = WireMockServer.Start(8081);
            server
                .Given(Request.Create().WithPath("/customerid")
                   )
                .RespondWith(Response.Create()
                    .WithBodyAsJson(new Customer().CustomerId = 123 )
                );

            server
                .Given(Request.Create().WithPath("/customerid")
                   )
                .RespondWith(Response.Create()
                    .WithBodyAsJson(new Customer().CustomerId = 123)
                );
        }


    }

    class Customer
    {
        public int CustomerId { get; set; } 
    }
}
