# ==============================
# „—Õ·… «·»‰«¡
# ==============================
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# ‰”Œ „·› «·Õ· Ê«·„‘—Ê⁄ „‰ «·„Ã·œ «·›—⁄Ì ZKP
COPY ["ZKP.sln", "."]
COPY ["ZKP/ZKP.csproj", "ZKP/"]

# «” ⁄«œ… «·Õ“„
RUN dotnet restore "ZKP/ZKP.csproj"

# ‰”Œ »«ﬁÌ „·›«  «·„‘—Ê⁄
COPY . .

# ÷»ÿ „”«— «·⁄„· ··„Ã·œ «·›—⁄Ì
WORKDIR "/src/ZKP"

# »‰«¡ «·„‘—Ê⁄
RUN dotnet build "ZKP.csproj" -c Release -o /app/build

# ==============================
# „—Õ·… «·‰‘—
# ==============================
FROM build AS publish
RUN dotnet publish "ZKP.csproj" -c Release -o /app/publish

# ==============================
# „—Õ·… «· ‘€Ì·
# ==============================
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80

#  ‘€Ì· «· ÿ»Ìﬁ
ENTRYPOINT ["dotnet", "ZKP.dll"]