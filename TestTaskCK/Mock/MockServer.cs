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
                    .WithBodyAsJson(new Customer().CustomerId = 123)
                );

            server
                .Given(Request.Create().WithBody(new JsonPathMatcher("$..order_lines[?(@.product_id == 'Existing Product')]"))
                )
                .RespondWith(Response.Create()
                    .WithBodyFromFile("./Mappings/Success.json")
                );

            server
                .Given(Request.Create().WithBody(new JsonPathMatcher("$..order_lines[?(@.product_id == 'NotExistedProduct')]"))
                )
                .RespondWith(Response.Create()
                    .WithBodyFromFile("./Responses/NotExistedProduct.json")
                );

            server
           .Given(Request.Create().WithBody(new JsonPathMatcher("$..order_lines[?(@.total_amount == 1000)]"))
           )
           .RespondWith(Response.Create()
               .WithBodyFromFile("./Responses/IncorrectPrice.json")
           );

        }

    }

    class Customer
    {
        public int CustomerId { get; set; } 
    }
}
