@page "/inventory"
@inject HttpClient Http

<h3>Inventory List</h3>
<ul>
    @foreach (var item in inventory)
    {
        <li>@item</li>
    }
</ul>

@code {
    private List<string> inventory = new();
    
    protected override async Task OnInitializedAsync()
    {
        inventory = await Http.GetFromJsonAsync<List<string>>("/api/inventory");
    }
}

// Archivo: BlazorFrontEnd/Pages/_Imports.razor
@using System.Net.Http.Json
