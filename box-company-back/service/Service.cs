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
    
    public Box CreateBox(int height, int width, int length, string type, int amount)
    {
        return _infrastructure.CreateBox( height,  width,  length, type, amount);
    }

    public Box UpdateBox(int id, int height, int width, int length, string type, int amount)
    {
        return _infrastructure.UpdateBox(id, height, width, length, type, amount);
    }
	
    public bool DeleteBox(int id)
    {
        return _infrastructure.DeleteBox(id);
    }
}