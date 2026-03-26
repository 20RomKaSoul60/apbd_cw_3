using System.CodeDom.Compiler;

namespace APBD3;

public class IdGenerator



{
    
    private static HashSet<long> unique_ids = new HashSet<long>();
    public static long generate()
    {
        long new_id = 0;
        do
        {
            new_id = Random.Shared.NextInt64(1, 1000);
        } while (unique_ids.Contains(new_id));
        unique_ids.Add(new_id);

        return new_id;
    }
}