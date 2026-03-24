using UnityEngine;

public interface EnnemieInterface
{
    public void IDamageble(float DamageTaken);

}

public interface IAmo
{
    public void AddAmo(int amotoadd);
    public int GetAmo();

    public void AddNumberKilled();


}
