
export interface AppEvent{
    id: number;
    title: string;
    description: string;
    date: string;
    location: Location;

}

export interface Location {
    lat: number;
    long: number;
    address: string;
}
