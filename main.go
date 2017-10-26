package main

import (
	"net/http"
);

func main() {
	http.HandleFunc("/", serverHandler)
	http.ListenAndServe(":27273", nil)
}
