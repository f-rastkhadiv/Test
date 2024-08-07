# LearningBlogAPI

LearningBlogAPI is a RESTful API designed to manage a learning blog where users can read articles and take quizzes. The API supports CRUD operations on articles and quizzes, and provides an endpoint for users to submit quiz answers and receive scores.

## Table of Contents

- [Features](#features)
- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Design Pattern](#design-pattern)
- [Libraries Used](#libraries-used)
- [Unit Testing](#unit-testing)
- [Docker Setup](#docker-setup)
- [Contributing](#contributing)
- [License](#license)

## Features

- Create, read, update, and delete articles.
- Create quizzes related to articles.
- Retrieve quizzes for a specific article.
- Submit quiz answers and receive a score.
- Containerized application for easy deployment.

## Requirements

- .NET Core 8.0 SDK
- SQLite
- Docker (for containerization)
- Git

## Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/f-rastkhadiv/LearningBlogAPI.git
   cd LearningBlogAPI
