# CleanArchMVC
Clean Architecture .NET Core

# Relacionamento e dependência entre os projetos
- CleanArchMVC.Domain: Não possui nenhuma dependência
- CleanArchMVC.Application: Dependência com o projeto: Domain
- CleanArchMVC.Infra.Data: Dependência com o projeto: Domain
- CleanArchMVC.Infra.IoC: Dependência com os projetos: Domain, Application e Infra.Data
- CleanArchMVC.WebUI: Dependência com o projeto: Infra.IoC
