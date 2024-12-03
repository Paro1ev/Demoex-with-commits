List<Order> repo = [
    new Order(1,new(2005,03,03),"микроволновкка", "коротнуло", "вставил в розетку и всё", "Игорь", "в ожидании" ),

    ];

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string message = "";

app.MapGet("/orders", (int param = 0) =>
{
    string buffer = message;
    message = "";
    if (param != 0)
        return new {repo = repo.FindAll(x => x.Number == param), message = buffer};
    return new {repo, message = buffer};
});

app.Run();


class Order (int number, DateOnly startDate, string device, string problemType, string description, string client, string status )
{
    public int Number { get; set; } = number;
    public DateOnly StartDate { get; set; } = startDate;
    public string Device { get; set; } = device;
    public string ProblemType { get; set; } = problemType;
    public string Description { get; set; } = description;
    public string Client { get; set; } = client;
    public string Status { get; set; } = status;
    public DateOnly? EndDate { get; set; } = null;
    public string? Master { get; set; } = "не назначен";
    public List<string> Comments { get; set; } = [];

}

record class UpdateOrderDTO(int Number, string? Status = "", string? Description = "", string? Master = "", string? Comment = "" );