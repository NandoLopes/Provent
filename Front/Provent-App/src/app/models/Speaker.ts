import { Event } from "./Event";
import { SocialNetwork } from "./SocialNetwork";

export interface Speaker {
    id: number;
    name: string;
    miniResume: string;
    imageURL: string;
    phone: string;
    email: string;
    socialNetworks: SocialNetwork[];
    speakersEvents: Event[];
}
