static void FileRead(List</**/> list)
{
    using StreamReader sr = new(@"..\..\..\src\");
    _ = sr.ReadLine();
    while (!sr.EndOfStream) list.Add(new /**/(sr.ReadLine()));
}
