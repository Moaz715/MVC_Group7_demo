@using MVC_Group7_demo_BLL.ModelVM
@model RegisterVM

@{
    Layout = "/Views/Shared/newLayout.cshtml";
}

<div class="card">
    <div class="card-header">
        Sign Up
    </div>
    <div class="card-body">
        <form asp-controller="Account" asp-action="SignUp" method="post" enctype="multipart/form-data">

            <div class="mb-3">
                <label asp-for="Name" class="form-label"></label>
                <input asp-for="Name" class="form-control" />
                <span asp-validation-for="Name" class="text-danger"></span>
            </div>

            <div class="mb-3">
                <label asp-for="Email" class="form-label"></label>
                <input asp-for="Email" type="email" class="form-control" />
                <span asp-validation-for="Email" class="text-danger"></span>
            </div>

            <div class="mb-3">
                <label asp-for="Password" class="form-label"></label>
                <input asp-for="Password" type="password" class="form-control" />
                <span asp-validation-for="Password" class="text-danger"></span>
            </div>

            <div class="mb-3">
                <label asp-for="Phone" class="form-label"></label>
                <input asp-for="Phone" class="form-control" />
                <span asp-validation-for="Phone" class="text-danger"></span>
            </div>

            <div class="mb-3">
                <label asp-for="Location" class="form-label"></label>
                <select asp-for="Location" class="form-select">
                    <option value="Cairo">Cairo</option>
                    <option value="Alexandria">Alexandria</option>
                    <option value="Giza">Giza</option>
                </select>
                <span asp-validation-for="Location" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-primary">Submit</button>

        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
