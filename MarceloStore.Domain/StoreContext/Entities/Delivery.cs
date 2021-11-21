using System;
using MarceloStore.Domain.StoreContext.Enums;
using MarceloStore.Shared.Entities;

namespace MarceloStore.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliveryDate){
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }
        
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }
        
        public void Ship()
        {
            //Se a data estimada de entrega for no passado, nao entregar
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            //Se o status ja estiver entregue, não pode cancelar
            Status = EDeliveryStatus.Canceled;
        }
    }
}