using box_company_back.infrastructure;
using box_company_back.models;

namespace box_company_back.service;

public class Service
{
    private readonly Infrastructure _infrastructure;

    public Service(Infrastructure infrastructure)
    {
        _infrastructure = infrastructure;
    }
    
    public IEnumerable<Box> GetAllBoxes()
    {
        try
        {
            return _infrastructure.GetAllBoxes();
        }
        catch (Exception)
        {
            throw new Exception("Could not get boxes");
        }
    }
}