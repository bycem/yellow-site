using Domain.Abstractions;

namespace Domain.ValueObjects;

public class VehicleValueObject : BaseValueObject
{
    public VehicleValueObject(string brand, string model, int modelYear)
    {
        Brand = brand;
        Model = model;
        ModelYear = modelYear;
    }


    public string Brand { get; protected set; }
    public string Model { get; protected set; }
    public int ModelYear { get; protected set; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Brand;
        yield return Model;
        yield return ModelYear;
    }
}