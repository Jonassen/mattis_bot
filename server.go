package main

import (
	"net/http"
	"fmt"
)

func serverHandler(w http.ResponseWriter, r *http.Request) {
	fmt.Fprint(w, "dank")
}