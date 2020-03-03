# PNLCalculator
Develop a demo console app (preferably C#) – a TRADE NETTER that behaves in the following way:
• Functionally, it processes a list of trades, calculating the PNL which indicates how much money
has been made/lost on buying and selling.
• Firstly, a balancing process is run which matches buys and sells, in a FIFO manner, depending on
the order or their entry:
o BUY 2 lots + SELL 1 lot + BUY 3 lots
  -> PNL 1 lot + BUY 1 lot + BUY 3 lots
  -> PNL 1 lot + BUY 4 lots
o BUY 2 lots + BUY 1 lot + SELL 4 lots
  -> BUY 3 lots + SELL 4 lots
  -> SELL 1 lot

• The resulting PNL is the gain or loss of the balancing process (if we have a trade buying for 100
and selling for 110, we have made a profit of 10 for each unit). The amount of the PNL is negative
is we lose money and positive is we receive money.
• The balancing algorithm is calculated in the order of first come/first processed.
