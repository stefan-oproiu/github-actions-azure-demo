## Github Actions and Azure Pipelines Demo with ASP.NET Core Services

This repository contains two ASP.NET Core services named ServiceA and ServiceB, which demonstrate how to build a deployment pipeline using Github Actions and Azure Pipelines.

### Overview
ServiceA is a web API that exposes an endpoint /api/hello on port 80. When this endpoint is called, it internally calls /api/internal endpoint on ServiceB.

ServiceB is also a web API that exposes an endpoint /api/internal on port 80, but this port is not exposed on the host machine, only inside the Docker network.

To run the project, you need to build it with docker-compose.

### Running the project
To run the project, you need to follow these steps:

1. Clone the repository: 
```git clone https://github.com/stefan-oproiu/github-actions-azure-demo.git```

2. Change directory to the project: ```cd github-actions-azure-demo```

3. Build the services with docker-compose: ```docker-compose build```

4. Start the services with docker-compose: ```docker-compose up```

Once the services are up and running, you can access ServiceA at http://localhost:80/api/hello. This will call the /api/internal endpoint on ServiceB and return a response.

### Github Actions
This project includes a Github Actions pipeline that builds and deploys the services to a Docker registry. The pipeline is triggered when changes are pushed to the main branch of the repository.

### Azure Pipelines
This project also includes an Azure Pipelines pipeline that deploys the services to an Azure Kubernetes Service (AKS) cluster. The pipeline is triggered when a new image is pushed to the Docker registry.

### License
This project is licensed under the MIT License. See the LICENSE file for details.

This `README.md` file was generated with ChatGPT.
