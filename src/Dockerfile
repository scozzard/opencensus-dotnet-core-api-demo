FROM microsoft/dotnet:2.2-sdk
ARG PROJECT_NAME
ENV PROJECT_NAME ${PROJECT_NAME}
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 5001
CMD ["sh", "-c", "dotnet run --project $PROJECT_NAME/$PROJECT_NAME.csproj"]
