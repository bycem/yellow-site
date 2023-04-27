using Domain.Abstractions;

namespace Domain.ValueObjects;

public class VehicleValueObject : BaseValueObject
{
    public VehicleValueObject(string brand, string model, int modelYear)
    {
        if (string.IsNullOrEmpty(brand))
        {
            throw new ArgumentException($"{nameof(Brand)} cannot be null or empty");
        }

        if (string.IsNullOrEmpty(model))
        {
            throw new ArgumentException($"{nameof(Model)} cannot be null or empty");
        }

        if (modelYear < 1900 || modelYear > DateTime.Now.Year + 1)
        {
            throw new ArgumentException($"{ModelYear} cannot be lower than 1900 or greater than next year");
        }

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