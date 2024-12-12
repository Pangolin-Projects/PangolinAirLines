export class Flight {
  id: string;
  airCraft: string;
  availableSeats: number;
  takeOff: string;
  landing: string;

  constructor(id: string, airCraft: string, availableSeats: number, takeOff: string, landing: string) {
    this.id = id;
    this.airCraft = airCraft;
    this.availableSeats = availableSeats;
    this.takeOff = takeOff;
    this.landing = landing;
  }
}
