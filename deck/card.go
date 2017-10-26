package deck

import "fmt"

var chars = []string{"2","3","4","5","6","7","8","9","T","J","Q","K","A"}

type card struct {
	suite string
	rank  int
}

func (c *card) shortString() string {
	return fmt.Sprintf("%v%v", chars[c.rank], c.suite[:1])
}
