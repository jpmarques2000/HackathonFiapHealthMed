# Bem vindo ao Hackathon do grupo 30!

O software da **Health&Med** otimiza seus de agendamentos de consultas médicas, tornando 100% digital e mais ágil.

O objetivo deste software é permitir o cadastro de médicos e pacientes, juntamente com a autenticação de ambos. Após o cadastro, os médicos poderão disponibilizar seus horários de atendimento, e os pacientes poderão agendar consultas com base na agenda disponível de cada médico.


# Tecnologias implementadas

 - DOT NET 7
	 - ASP.NET WebApi
	 - ASP.NET Identity Core
	 - Entity Framework 7
	 - JWT Bearer Authentication      
	 
 - Component/Service
	 - Swagger UI
	 - Redoc
	 - Flunt Validation
	 - Automapper
 - Hosting
	 - Docker Compose

  - ## Instalação
Você pode executar o projeto **Health$Med** em qualquer sistema operacional. Certifique-se de ter instalado o docker e o Visual Studio em seu ambiente. 

(Obter instalação do Docker) --> https://www.docker.com/products/docker-desktop/

Clone o repositório **HackathonFiapHealthMed** --> git clone https://github.com/jpmarques2000/HackathonFiapHealthMed.git

Na solução HealthMed selecione Clean Solution --> Build Solution --> Restore NuGetPackages

Vá para o Package Manager Console na solução Presentation.API.

Execute os seguintes comandos

    docker-compose up -d
    update-database
