package main

import (
	"fmt"
	"github.com/GerardoHP/test_k8s_app/src/dateService/github.com/GerardoHP/test_k8s_app/src/dateService"
	"log"
	"net"

	"google.golang.org/grpc"
)

func main() {
	lis, err := net.Listen("tcp", ":8080")
	if err != nil {
		log.Fatalf("Failed to listen: %v \n", err)
	}

	s := grpc.NewServer()
	dateService.RegisterMyServiceServer(s, &dateService.Server{})
	if err := s.Serve(lis); err != nil {
		log.Fatalf("failed to serve: %v \n", err)
	}

	fmt.Println("now listening")
}
