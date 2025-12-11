# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# äÓÎ ãáİ ÇáãÔÑæÚ æÇÓÊÚÇÏÉ ÇáÍÒã
COPY ["ZKP.csproj", "./"]
RUN dotnet restore "ZKP.csproj"

# äÓÎ ÈÇŞí ÇáãáİÇÊ æÈäÇÁ ÇáãÔÑæÚ
COPY . .
RUN dotnet build "ZKP.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish "ZKP.csproj" -c Release -o /app/publish

# Stage 3: Final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

# äÓÎ ãáİÇÊ ÇáãÔÑæÚ ÇáãäÔæÑ
COPY --from=publish /app/publish .

# ÊÚííä ÇáãäİĞ ÇáĞí ÓíÚãá Úáíå ÇáÊØÈíŞ
EXPOSE 80

# ÊÔÛíá ÇáãÔÑæÚ
ENTRYPOINT ["dotnet", "ZKP.dll"]