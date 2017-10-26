package deck

import (
	"math/rand"
	"time"
	"sort"
)

type Deck struct {
	cards []card
}

func NewDeck() Deck {
	var cards []card
	suites := []string{"hearts", "spades", "diamonds", "clubs"}
	for _, suite := range suites{
		for i := 0; i <= 12; i++{
			card := card{
				suite: suite,
				rank: i,
			}
			cards = append(cards, card)
		}
	}
	return Deck{cards}
}

func (d *Deck) Shuffle() {
	var cardsCopy []card
	src := rand.NewSource(time.Now().UnixNano())
	rand := rand.New(src)
	perm := rand.Perm(len(d.cards))
	for _, val := range perm{
		cardsCopy = append(cardsCopy, d.cards[val])
	}
	d.cards = cardsCopy
}

func (d *Deck) String() string{
	var result string
	for _, card := range d.cards{
		result += card.shortString() + " "
	}
	return result
}

func (d *Deck) Len() int{
	return len(d.cards)
}
func (d *Deck) Swap(i, j int){
	d.cards[i], d.cards[j] = d.cards[j], d.cards[i]
}
func (d *Deck) Less(i, j int) bool {
	ci, cj := d.cards[i], d.cards[j]
	if ci.suite == cj.suite{
		return ci.rank < cj.rank
	}
	prio := []string{"hearts", "spades", "diamonds", "clubs"}
	for _, suite := range prio{
		if ci.suite == suite{
			return true
		}
		if cj.suite == suite{
			return false
		}
	}
	return true
}

func (d *Deck) Sort(){
	sort.Sort(d)
}
