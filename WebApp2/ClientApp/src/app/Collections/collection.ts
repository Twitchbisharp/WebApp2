export interface ICollection {
  collectionId: number;
  collectionDate: string;
  collectionName: string;
  collectionFlashcardId: number;
  collectionFlashcard?: any;
  totalFlashcards: number;
  contributerId: number;
  contributers?: any;
}
