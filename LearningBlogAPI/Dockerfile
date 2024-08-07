# Use the official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official ASP.NET Core SDK as a build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LearningBlogAPI/LearningBlogAPI.csproj", "LearningBlogAPI/"]
RUN dotnet restore "LearningBlogAPI/LearningBlogAPI.csproj"
COPY . .
WORKDIR "/src/LearningBlogAPI"
RUN dotnet build "LearningBlogAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearningBlogAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearningBlogAPI.dll"]