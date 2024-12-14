export class Flight {
  id: string;
  airCraft: string;
  availableSits: number;
  takeOff: string;
  landing: string;

  constructor(id: string, airCraft: string, availableSits: number, takeOff: string, landing: string) {
    this.id = id;
    this.airCraft = airCraft;
    this.availableSits = availableSits;
    this.takeOff = takeOff;
    this.landing = landing;
  }
}
