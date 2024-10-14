using Project_01.Models;

namespace Project_01.Listener;

public class PrimaryEntityListener
{
    public void OnCreate(PrimaryEntity entity)
    {
        entity.CreateDate = DateTime.Now;
        entity.UpdateDate = DateTime.Now;
    }

    public void OnUpdate(PrimaryEntity entity)
    {
        entity.UpdateDate = DateTime.Now;
    }
}