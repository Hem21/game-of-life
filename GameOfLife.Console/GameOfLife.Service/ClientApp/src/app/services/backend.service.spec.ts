import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed, getTestBed, fakeAsync } from '@angular/core/testing';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { take } from 'rxjs/operators';
import { BackEndService, Grid } from '../services/backend.service';

describe('BackEndService', () => {
  let service: BackEndService;
  let httpMock;
  let injector: TestBed;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        HttpClientTestingModule,
      ],
      providers: [{ provide: 'BASE_URL', useValue: 'http://baseurl.com/' }]
    }).compileComponents();

    injector = getTestBed();
    httpMock = injector.get(HttpTestingController);
    service = injector.get(BackEndService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get results from endpoint', fakeAsync(() => {
    const url = 'http://baseurl.com/creategrid/';

    service.requestGrid(1, 2).pipe(take(1)).subscribe(results => {
      expect(results).toBeDefined();
      expect(results.columns).toEqual(1);
      expect(results.rows).toEqual(2);
    });

    const body = {};
    const backendResult: Grid = { columns: 1, rows: 2 };
    const mockedbackendRequest = httpMock.expectOne(url);

    expect(mockedbackendRequest.request.method).toEqual('POST');
    expect(mockedbackendRequest.request.body).toEqual(body);

    mockedbackendRequest.flush(backendResult);
    httpMock.verify();
  }));

});
