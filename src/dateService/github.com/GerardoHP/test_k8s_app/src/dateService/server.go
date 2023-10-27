package dateService

import (
	"fmt"
	"golang.org/x/net/context"
)

type Server struct{}

func (s *Server) mustEmbedUnimplementedMyServiceServer() {
}

var _ MyServiceServer = (*Server)(nil)

func (s *Server) SayHello(
	ctx context.Context,
	in *HelloRequest,
) (*HelloResponse, error) {
	fmt.Printf("received %v in grpc \n", in.Name)
	return &HelloResponse{Message: "Hello " + in.Name}, nil
}
