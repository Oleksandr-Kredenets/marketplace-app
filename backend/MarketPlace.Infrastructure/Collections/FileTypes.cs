namespace MarketPlace.Infrastructure.Collections;

public static class FileTypes{
    public static HashSet<string> Types {get;} = new HashSet<string>
    {
        "image/jpeg",
        "image/png"
    };
}