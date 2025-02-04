FROM mcr.microsoft.com/devcontainers/dotnet:8.0

# Set the working directory
WORKDIR /app

# Copy all the files from the current directory to /app in the container
COPY . /app

# Change ownership of the /app directory to the vscode user
RUN chown -R vscode:vscode /app

# Switch to the vscode user
USER vscode

# Expose port 8080
EXPOSE 8080

# Keep the container running
CMD ["sleep", "infinity"]
