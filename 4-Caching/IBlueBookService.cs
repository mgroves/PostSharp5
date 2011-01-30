namespace Caching
{
    public interface IBlueBookService
    {
        decimal GetCarValue(int year, CarMakeAndModel carType);
    }
}