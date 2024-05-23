import { Batch } from "./Batch";
import { Speaker } from "./Speaker";
import { SocialNetwork } from "./SocialNetwork";

export interface Event {
    id: number;
    place: string;
    theme: string;
    eventDate?: Date;
    capacity: number;
    imageURL: string;
    phone: string;
    email: string;
    batches: Batch[];
    socialNetworks: SocialNetwork[];
    eventsSpeakers: Speaker[];
}
