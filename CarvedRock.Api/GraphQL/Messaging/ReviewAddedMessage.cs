﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL.Messaging
{
    public class ReviewAddedMessage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Review { get; set; }
    }
}
