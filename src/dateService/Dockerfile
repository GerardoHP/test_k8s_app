FROM golang:1.20-alpine as build
WORKDIR /app
COPY go.??? /app/
RUN go mod download && \
    go mod tidy
COPY . /app/
RUN go mod tidy && \
    go build -o grpc_server ./main.go

FROM alpine:latest

EXPOSE 8080
WORKDIR /app
COPY --from=build /app/grpc_server /app/
RUN chmod +x /app/grpc_server
ENV PATH=$PATH:/app
CMD grpc_server