using EA.JP.Ecommerce.Infrastructure.Domain;

namespace EA.JP.Ecommerce.Model.Basket
{
    public class BasketBusinessRules
    {
        public static readonly BusinessRule DeliveryOptionRequired =
                    new BusinessRule("DeliveryOption",
                                        "An order must have a valid delivery option.");
        public static readonly BusinessRule ItemInvalid =
                    new BusinessRule("Item", "A basket cannot have any invalid items.");
    }

}
