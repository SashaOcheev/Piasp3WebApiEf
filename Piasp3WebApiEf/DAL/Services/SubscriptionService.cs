using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Piasp3WebApiEf.DAL.Models;
using System.Data.Entity;

namespace Piasp3WebApiEf.DAL.Services
{
    public class SubscriptionService : DbContext, ISubscriptionService
    {
        public SubscriptionService()
            : base( "DbConnection" )
        { }

        public DbSet<Subscription> Subscriptions { get; set; }

        public Subscription Get( int Id )
        {
            return Subscriptions.SingleOrDefault( x => x.Id == Id );
        }

        public void Save( Subscription subscription )
        {
            var existSubscription = Get( subscription.Id );
            if ( existSubscription != null )
            {
                existSubscription.Id = subscription.Id;
            }
            else
            {
                Subscriptions.Add( subscription );
            }
            SaveChanges();
        }
    }
}