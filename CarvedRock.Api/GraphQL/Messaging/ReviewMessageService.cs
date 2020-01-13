using CarvedRock.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL.Messaging
{
    public class ReviewMessageService
    {
        readonly ISubject<ReviewAddedMessage> _messageStream = new ReplaySubject<ReviewAddedMessage>(1);

        public ReviewAddedMessage AddReviewAddedMessage(ProductReview review)
        {
            var message = new ReviewAddedMessage
            {
                Id = review.Id,
                ProductId = review.ProductId,
                Title = review.Title,
                Review = review.Review
            };

            _messageStream.OnNext(message); // Will send the message to all subscribers
            return message;
        }

        public IObservable<ReviewAddedMessage> GetMessages() => _messageStream.AsObservable();
    }
}
