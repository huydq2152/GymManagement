using ErrorOr;

namespace GymManagement.Domain.Gyms;

public static class GymErrors
{
    public static readonly Error CannotHaveMoreRoomsThanSubscriptionAllows = Error.Validation(
        "Room.CannotHaveMoreRoomsThanSubscriptionAllows",
        "A gym cannot have more rooms than the subscription allows");

    public static readonly Error TrainerIsAlreadyAdded = Error.Conflict(
        "Trainer.TrainerIsAlreadyAdded",
        "Trainer already added to gym");
}