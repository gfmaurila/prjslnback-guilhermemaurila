# Desafio Back-End

# Iniciar os segredos de usuários
- dotnet user-secrets init --project .\Prjslnback-API.csproj 
- dotnet user-secrets list --project .\Prjslnback-API.csproj

# Configurar a string de conexão ao banco de dados
- dotnet user-secrets set "ConnectionStrings:Prjslnback" "Server=localhost,1433;Database=Prjslnback;User=sa;Password=***;MultipleActiveResultSets=true"
- dotnet user-secrets list --project .\Prjslnback-API.csproj

# Configurar dados de autenticação (JWT)
- dotnet user-secrets set "Jwt:Key" "cHJqc2xuYmFjay1ndWlsaGVybWVtYXVyaWxh"
- dotnet user-secrets set "Jwt:Login" "login"
- dotnet user-secrets set "Jwt:Password" "*****"

# Deletar um segredo de usuário da aplicação.
- dotnet user-secrets remove "[CHAVE]"

# Banco
- cd Prjslnback-Infra
- Add-Migration InitialCreate
- Update-Database

# Estrutura da API
- .NET Core 5: Framework para desenvolvimento da Microsoft.
- AutoMapper: Biblioteca para realizar mapeamento entre objetos.
- Swagger: Documentação para a API.
- DDD: Domain Drive Design modelagem de desenvolvimento orientado a injeção de dependência.
- Entity FrameWork
- XUnit
- FluentValidator
- JWT